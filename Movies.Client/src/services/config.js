import axios from 'axios'

class Config {
    async apiUrl() {
        return await axios.get('../config.json').data.api_url;
    }
}

export default new Config();