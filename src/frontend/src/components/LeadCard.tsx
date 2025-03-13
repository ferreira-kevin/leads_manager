interface LeadProps {
    lead: {
        id: number;
        name: string;
        date: string;
        location: string;
        category: string;
        jobId: number;
        description: string;
        price: number;
    };
    onAccept: (id: number) => void;
    onDecline: (id: number) => void;
}

import React from 'react';
import {
  Card,
  CardContent,
  Avatar,
  Typography,
  Box,
  Divider,
  Button
} from '@mui/material';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import WorkIcon from '@mui/icons-material/Work';

interface LeadProps {
    id: number;
    contactFirstName: string;
    dateCreated: string;
    suburb: string;
    category: string;
    jobId: number;
    description: string;
    price: number;
}

interface LeadCardProps {
  lead: LeadProps;
  onAccept: (id: number) => void;
  onDecline: (id: number) => void;
}

const LeadCard: React.FC<LeadCardProps> = ({ lead, onAccept, onDecline }) => {
  const avatarLetter = lead.contactFirstName ? lead.contactFirstName[0].toUpperCase() : '?';

  return (
    <Card
      sx={{
        marginBottom: 2,
        borderRadius: 1,
        boxShadow: 1,
      }}
    >
      <CardContent>
        <Box sx={{ display: 'flex', alignItems: 'center', marginBottom: 1 }}>
          <Avatar sx={{ bgcolor: '#ff9f42', marginRight: 2 }}>
            {avatarLetter}
          </Avatar>
          <Box>
            <Typography variant="subtitle1" fontWeight="bold">
              {lead.contactFirstName ?? 'firstName'}
            </Typography>
            <Typography variant="caption" color="text.secondary">
              {lead.dateCreated ?? '12/04/2024'}
            </Typography>
          </Box>
        </Box>

        <Divider />

        <Box
          sx={{
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'flex-start',
            marginY: 1,
            flexWrap: 'wrap',
          }}
        >
          <Typography
            variant="body2"
            color="text.secondary"
            sx={{ display: 'flex', alignItems: 'center', mr: 2, mb: 1 }}
          >
            <LocationOnIcon sx={{ fontSize: 18, marginRight: 0.5, color: 'GrayText' }} />
            {lead.suburb ?? 'location'}
          </Typography>
          <Typography
            variant="body2"
            color="text.secondary"
            sx={{ display: 'flex', alignItems: 'center', mr: 2, mb: 1 }}
          >
            <WorkIcon sx={{ fontSize: 18, marginRight: 0.5, color: 'GrayText' }} />
            {lead.category ?? 'category'}
          </Typography>
          <Typography variant="body2" color="text.secondary" sx={{ mb: 1 }}>
            Job ID: {lead.jobId ?? '34645646'}
          </Typography>
        </Box>

        <Divider />

        <Box sx={{ marginY: 1 }}>
          <Typography variant="body2" color="text.secondary">{lead.description ?? 'description description description description description'}</Typography>
        </Box>

        <Divider />
        <Box
          sx={{
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'space-between',
            marginTop: 1,
          }}
        >
          <Box>
            <Button
              variant="contained"
              sx={{
                backgroundColor: '#ff7b19',
                color: '#fff',
                marginRight: 1,
                '&:hover': {
                  backgroundColor: '#e86e0f',
                },
              }}
              onClick={() => onAccept(lead.id)}
            >
              Accept
            </Button>
            <Button
              variant="outlined"
              sx={{
                borderColor: '#ff7b19',
                color: '#ff7b19',
                '&:hover': {
                  borderColor: '#e86e0f',
                  color: '#e86e0f',
                },
              }}
              onClick={() => onDecline(lead.id)}
            >
              Decline
            </Button>
          </Box>
          <Typography variant="body2">
            <strong>${lead.price.toFixed(2)}</strong> Lead Invitation
          </Typography>
        </Box>
      </CardContent>
    </Card>
  );
};

export default LeadCard;
