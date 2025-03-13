import React from 'react';
import { ThemeProvider, CssBaseline, Box, Tabs, Tab } from '@mui/material';
import theme from '../theme';
import { containerStyle, tabsContainerStyle, tabsStyle, contentStyle } from './Leads.styles';
import InvitedLeads from './InvitedLeads';
import AcceptedLeads from './AcceptedLeads';

const Leads: React.FC = () => {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Box sx={containerStyle}>
        <Box sx={tabsContainerStyle}>
          <Tabs
            value={value}
            onChange={handleChange}
            variant="fullWidth"
            indicatorColor="primary"
            textColor="inherit"
            sx={tabsStyle}
          >
            <Tab label="Invited" />
            <Tab label="Accepted" />
          </Tabs>
        </Box>
        <Box sx={contentStyle}>
          {value === 0 && <Box><InvitedLeads /></Box>}
          {value === 1 && <Box><AcceptedLeads /></Box>}
        </Box>
      </Box>
    </ThemeProvider>
  );
};

export default Leads;
