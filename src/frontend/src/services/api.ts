import axios from "axios";

const API_URL = "https://localhost:7079/api/leads";

export const getInvitedLeads = async () => {
    const response = await axios.get(`${API_URL}/invited`);
    return response.data;
};

export const getAcceptedLeads = async () => {
    const response = await axios.get(`${API_URL}/accepted`);
    return response.data;
};

export const acceptLead = async (id: number) => {
    await axios.post(`${API_URL}/accept/${id}`);
};

export const declineLead = async (id: number) => {
    await axios.post(`${API_URL}/decline/${id}`);
};
