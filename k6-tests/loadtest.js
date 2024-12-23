import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  vus: 100,
  duration: '5m',
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