import Axios from 'axios';
Axios.defaults.baseURL = 'https://friends-series.jedlik.cloud';

export default {
    getEpisodesByID(filter, page){
        return Axios.get(`/api/friends?name_like=${filter}&_page=${page}&_limit=15&_expand=season`)
    }
}