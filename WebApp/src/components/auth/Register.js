const Register = () => {
  return (
    <div className="auth_wrapper">
      <div className="auth_title">Registreer je nu en ontvang je punten</div>
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
        <div class="input-field">
          <label for="password">Herhaal wachtword</label>
          <input
            type="password"
            placeholder="********"
            id="password"
            name="password"
          />
        </div>
        <div class="action">
          <button id="btn" class="btn">
            Registreer nu
          </button>
        </div>
      </div>
    </div>
  );
};

export default Register;
