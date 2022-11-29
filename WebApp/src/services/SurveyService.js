import http from "../http-common";

const getAll = () => {
    return http.get("/v3/surveys/509691265/details")
  }
  

const functions = {
    getAll,
  }
  
  export default functions;
  