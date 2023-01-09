
const LoginRegister = () => {
  return (
    <div style={{ marginTop: '60%', padding: 24 }}>
      <div className="action">
        <button id="btn" className="btn" onClick={event =>  window.location.href='/login'}>
          Inloggen
        </button>
      </div>
      <div className="action">
        <button id="btn" className="btn" onClick={event =>  window.location.href='/survey'}>
          Nieuwe gebruiker
        </button>
      </div>
    </div>
  )
};

export default LoginRegister;