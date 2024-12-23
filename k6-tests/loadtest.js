import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  vus: 1000,
  duration: '60s',
  cloud: {
    // LIVEDJ-Project
    projectID: 3727684,
    name: 'Livestream-Service Load Test'
  }
};

export default function() {
  http.get('http://35.202.177.253:8080/swagger/index.html');
  sleep(1);
}