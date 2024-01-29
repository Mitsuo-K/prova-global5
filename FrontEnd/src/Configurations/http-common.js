import axios from 'axios';
import appointments from './appointments';

const http = axios.create({
    baseURL: appointments.baseURL,
    headers: {
        Accept: 'application/json',
        'Content-Type': 'text/json',
    }
});

export default http;