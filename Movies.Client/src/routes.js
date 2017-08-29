import dashboard from './pages/dashboard.vue'
import peliculas from './pages/peliculas.vue'
import personas from './pages/personas.vue'

const routes = [
    {
        name: 'dashboard',
        path: '/',
        component: dashboard
    },
    {
        name: 'peliculas',
        path: '/peliculas',
        component: peliculas
    },
    {
        name: 'personas',
        path: '/personas',
        component: personas
    }
];

export default routes