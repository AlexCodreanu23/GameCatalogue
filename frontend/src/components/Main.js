import React from 'react';
import { useNavigate } from 'react-router-dom';

function Main() {
  const navigate = useNavigate();

  return (
    <div className="container">
      <h1>Welcome</h1>
      <button onClick={() => navigate('/login')}>Login</button>
      <button onClick={() => navigate('/register')}>Register</button>
    </div>
  );
}

export default Main;
