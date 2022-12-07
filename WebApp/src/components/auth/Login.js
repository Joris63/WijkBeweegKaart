const Login = () => {
  return (
    <div className="auth_wrapper">
      <div className="auth_title">Login om meer punten te verdienen</div>
      <div className="auth_form">
        <div class="input-field">
          <label for="email">E-mailadres of gebruikersnaam</label>
          <input
            type="email"
            placeholder="example@example.com"
            id="email"
            name="email"
          />
        </div>
        <div class="input-field">
          <label for="password">Wachtwoord</label>
          <input
            type="password"
            placeholder="********"
            id="password"
            name="password"
          />
        </div>
        <div class="action">
          <button id="btn" class="btn">
            Inloggen
          </button>
        </div>
      </div>
    </div>
  );
};

export default Login;
