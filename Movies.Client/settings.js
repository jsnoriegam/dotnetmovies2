// Ponemos este archivo fuera de src para que no sea incluido en la empaquetación
// Debemos utilizar una etiqueta <script> para añadirlo a index.html antes de app.js
"use strict"
if(!window.movies) {
    // declaramos movies como un objeto global (para acceder solo necesitamos usar movies)
    window.movies = {
        api_url: 'http://localhost:5000/api/v1'
    };
}