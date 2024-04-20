import './App.css';
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import api  from './api/Api';

function App() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  return (
    <div className="mt-3 d-flex justify-content-center align-items-center">
      <div className="col-md-6">
          <div className="mb-3">
            <label htmlFor="email">Email</label>
            <input type="text" value = {email} onChange={(e => setEmail(e.target.value))} id="email" name="email" className="form-control mt-2" placeholder="Email" />
          </div>
          <div className="mb-3">
            <label htmlFor="password">Password</label>
            <input type="password" value = {password} onChange={e => setPassword(e.target.value)} id="password" name="password" className="form-control mt-2" placeholder="Password"/>
          </div>
          <div className="col-12">
          <button className="btn btn-outline-success me-2" onClick={sendEmail}>Login</button>
          <button className="btn btn-outline-success">Criar Usuario</button>
          </div>
      </div>
    </div>
  );

  async function sendEmail() {
    debugger
    await api.get(`user/${email}`)
  }

}


export default App;
