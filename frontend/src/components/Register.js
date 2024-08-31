import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Register() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleRegister = () => {
        if (email && password) {
            const users = JSON.parse(localStorage.getItem('users')) || [];
            if (!users.some(user => user.email === email)) {
                users.push({ email, password });
                localStorage.setItem('users', JSON.stringify(users));
                alert('Registration successful!');
                navigate('/login');
            } else {
                alert('User already exists!');
            }
        } else {
            alert('Please enter both email and password');
        }
    };

    return (
        <div className="container">
            <h2>Register</h2>
            <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
            />
            <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
            />
            <button onClick={handleRegister}>Register</button>
        </div>
    );
}

export default Register;
