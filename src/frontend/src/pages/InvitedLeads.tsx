import React, { useEffect, useState } from "react";
import LeadCard from "../components/LeadCard";
import { getInvitedLeads, acceptLead, declineLead } from "../services/api";

const InvitedLeads: React.FC = () => {
    const [leads, setLeads] = useState([]);

    useEffect(() => {
        getInvitedLeads().then(setLeads);
    }, []);

    const handleAccept = async (id: number) => {
        await acceptLead(id);
        setLeads(leads.filter((lead) => lead.id !== id));
    };

    const handleDecline = async (id: number) => {
        await declineLead(id);
        setLeads(leads.filter((lead) => lead.id !== id));
    };

    return (
        <div>
            {leads.map((lead) => (
                <LeadCard key={lead.id} lead={lead} onAccept={handleAccept} onDecline={handleDecline} />
            ))}
        </div>
    );
};

export default InvitedLeads;
