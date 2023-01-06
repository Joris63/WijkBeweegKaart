import { login } from "../../api/axios";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();

  function handleLogin() {
    let loginJson = { username: username, password: password };
    login(loginJson)
      .then((res) => {
        console.log(res);
        const token = res.data.jwt;
        localStorage.setItem("token", token);

        navigate("/levels");
      })
      .catch((error) => {
        console.log(error);
      });
  }

  return (
    <div className="auth_wrapper">
      <div className="auth_title">Login om meer punten te verdienen</div>
      <div className="auth_form">
        <div className="input-field">
          <label htmlFor="username">Gebruikersnaam</label>
          <input
            type="email"
            id="username"
            name="username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="input-field">
          <label htmlFor="password">Wachtwoord</label>
          <input
            type="password"
            placeholder="********"
            id="password"
            name="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div className="action">
          <button id="btn" className="btn" onClick={handleLogin}>
            Inloggen
          </button>
        </div>
      </div>
    </div>
  );
};

export default Login;
