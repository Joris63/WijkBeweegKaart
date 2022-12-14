import { useNavigate } from "react-router-dom";

const Register = () => {
  const navigate = useNavigate();

  const routeChange = () => {
    let path = "levels";
    navigate(path);
  };

  return (
    <div className="auth_wrapper">
      <div className="auth_title">Registreer je nu en ontvang je punten</div>
      <div className="auth_form">
        <div className="input-field">
          <label htmlFor="email">E-mailadres of gebruikersnaam</label>
          <input
            type="email"
            placeholder="example@example.com"
            id="email"
            name="email"
          />
        </div>
        <div className="input-field">
          <label htmlFor="password">Wachtwoord</label>
          <input
            type="password"
            placeholder="********"
            id="password"
            name="password"
          />
        </div>
        <div className="input-field">
          <label htmlFor="password">Herhaal wachtword</label>
          <input
            type="password"
            placeholder="********"
            id="v-password"
            name="v-password"
          />
        </div>
        <div className="action">
          <button id="btn" className="btn" onClick={routeChange}>
            Registreer nu
          </button>
        </div>
      </div>
    </div>
  );
};

export default Register;
