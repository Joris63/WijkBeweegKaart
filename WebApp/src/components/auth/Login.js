const Login = () => {
  return (
    <div className="auth_wrapper">
      <div className="auth_title">Login om meer punten te verdienen</div>
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
        <div className="action">
          <button id="btn" className="btn">
            Inloggen
          </button>
        </div>
      </div>
    </div>
  );
};

export default Login;
