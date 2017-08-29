import axios from 'axios'

class PeliculasRepo {
    obtenerPeliculas() {
        return axios.get('http://localhost:5000/api/v1/peliculas');
    }

    obtenerPelicula(id) {
        return axios.get(`http://localhost:5000/api/v1/peliculas/${ id }`);
    }

    guardarPelicula(pelicula) {
        return axios.post('http://localhost:5000/api/v1/peliculas', pelicula);
    }
}

export default new PeliculasRepo();