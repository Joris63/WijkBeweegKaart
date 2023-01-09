import { useNavigate } from "react-router-dom";
import { register } from "../../api/axios";
import { useState } from "react";
import useAuth from "./../../hooks/useAuth";

const Register = () => {
  const navigate = useNavigate();
  const { setAuth } = useAuth();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const routeChange = () => {
    let path = "levels";

    navigate(path);
  };

  function handleRegister() {
    if (password === confirmPassword) {
      let registerJson = { username: username, password: password };
      register(registerJson)
        .then((res) => {
          console.log(res);

          setAuth({ user: registerJson });
          routeChange();
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }

  return (
    <div className="auth_wrapper">
      <div className="auth_title">Registreer je nu en ontvang je punten</div>
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
        <div className="input-field">
          <label htmlFor="password">Herhaal wachtword</label>
          <input
            type="password"
            placeholder="********"
            id="v-password"
            name="v-password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </div>
        <div className="action">
          <button id="btn" className="btn" onClick={handleRegister}>
            Registreer nu
          </button>
        </div>
        <a className="auth_mode_switch" href="/login">Al een account?</a>
      </div>
    </div>
  );
};

export default Register;
