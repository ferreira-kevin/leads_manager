import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Leads from "./pages/Leads";

const App: React.FC = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Leads />} />
            </Routes>
        </Router>
    );
};

export default App;
