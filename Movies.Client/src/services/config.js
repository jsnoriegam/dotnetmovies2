import axios from 'axios'

class Config {
    constructor() {
        async () => {
            let data = await axios.get('../config.json');
            this.api_url = data.api_url;
        }
    }
}

export default new Config();