import axios from "axios";

export const BASE_URL = "https://localhost:7264";

export default axios.create({
  baseURL: BASE_URL,
  withCredentials: true,
});

export const axiosPrivate = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
  withCredentials: true,
});

const setAuthToken = token => {
  if (token) {
      axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  }
  else
      delete axios.defaults.headers.common["Authorization"];
}

const register = (data) => {
  return axiosPrivate.post("/Users/Save", data);
};

const login = (data) => {
  return axiosPrivate.post("/Users/Login", data);
};

const getLevels = () =>
{
  return axiosPrivate.get("/Levels/Overview?userId=1")
}

export { register, login, setAuthToken };
