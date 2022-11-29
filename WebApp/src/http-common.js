import axios from "axios";

export default axios.create({
  baseURL: "https://api.surveymonkey.net",
  headers: {
    "Content-type": "application/json",
    "Authorization" : "bearer sZJQ0yv7hrbRgyKQWtC5hPPGGwQwIk1mbuYYqaSDpwyfvE1coBtss0bAq3KpaPJZVc6-ZATJIEfMtn3SwLM5UW2e6fCCiniKNRo2kDtq7b7z5p5fb1NltigIgg2U33MI"
  }
});
