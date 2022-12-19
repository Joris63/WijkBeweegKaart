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

const register = (data) => {
  return axiosPrivate.post("/Users/Save", data);
};

const getLevels = () =>
{
  return axiosPrivate.get("/Levels/Overview?userId=1")
}

export { register };
