import React from 'react';
import { useNavigate } from 'react-router-dom';
import { games } from '../data/games'; 

function Dashboard() {
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem('loggedInUser');
        navigate('/login');
    };

    return (
        <div className="dashboard-container">
            <div className="dashboard-header">
                <h2>GameCatalogue</h2>
                <button onClick={handleLogout} className="logout-button">Logout</button>
            </div>
            <div className="games-grid">
                {games.map(game => (
                    <div key={game.id} className="game-card">
                        <img src={game.image} alt={game.title} className="game-image" />
                        <h3>{game.title}</h3>
                        <p><strong>Platform:</strong> {game.platform}</p>
                        <p><strong>Genre:</strong> {game.genre}</p>
                        <p><strong>Release Date:</strong> {game.releaseDate}</p>
                        <p className="game-price"><strong>Price:</strong> {game.price}</p>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Dashboard;
