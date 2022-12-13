import axios from "axios";

const BASE_URL = "https://api.surveymonkey.net/v3";
const accessToken =
  "sZJQ0yv7hrbRgyKQWtC5hPPGGwQwIk1mbuYYqaSDpwyfvE1coBtss0bAq3KpaPJZVc6-ZATJIEfMtn3SwLM5UW2e6fCCiniKNRo2kDtq7b7z5p5fb1NltigIgg2U33MI";

const surveyMonkeyAxios = axios.create({
  baseURL: BASE_URL,
  headers: {
    Authorization: `Bearer ${accessToken}`,
  },
});

const getSurvey = () => {
    return surveyMonkeyAxios.get("/surveys/509691265/details");
};

const postSurvey = (data) => {
  return surveyMonkeyAxios.post("/collectors/448832583/responses", data)
}

export { getSurvey, postSurvey };