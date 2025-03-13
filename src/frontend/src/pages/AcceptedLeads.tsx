import React, { useEffect, useState } from "react";
import LeadCard from "../components/LeadCard";
import { getAcceptedLeads } from "../services/api";
import AcceptedLeadCard from "../components/AcceptedLeadCard";

const AcceptedLeads: React.FC = () => {
    const [leads, setLeads] = useState([]);

    useEffect(() => {
        getAcceptedLeads().then(setLeads);
    }, []);

    return (
        <div>
            {leads.map((lead) => (
                <LeadCard key={lead.id} lead={lead} onAccept={() => {}} onDecline={() => {}}/>
            ))}
        </div>
    );
};

export default AcceptedLeads;
