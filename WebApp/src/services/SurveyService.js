import http from "../http-common";

const getAll = () => {
    return http.get("surveys/509691265/details")
  }
  const post = (data) => {
    return http.post("collectors/448832583/responses", data)
  }
  

const functions = {
    getAll,
    post
  }
  
  export default functions;
  