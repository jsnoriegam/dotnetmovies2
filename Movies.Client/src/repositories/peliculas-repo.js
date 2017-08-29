import axios from 'axios'
import config from '../services/config'

console.log(config);

class PeliculasRepo {
    obtenerPeliculas() {
        return axios.get(`${ config.api_url }/peliculas`);
    }

    obtenerPelicula(id) {
        return axios.get(`${ config.api_url }/peliculas/${ id }`);
    }

    guardarPelicula(pelicula) {
        return axios.post(`${ config.api_url }/peliculas`, pelicula);
    }
}

export default new PeliculasRepo();