import React from 'react';
import { useNavigate } from 'react-router-dom';

function Dashboard() {
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem('loggedInUser');
        navigate('/login');
    };

    return (
        <div className="container">
            <h2>Dashboard</h2>
            <p>Welcome to your dashboard!</p>
            <button onClick={handleLogout}>Logout</button>
        </div>
    );
}

export default Dashboard;
