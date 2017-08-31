<template>
    <div>
        <h3>Ingresar al sistema</h3>
        <div class="row">
            <div class="col-md-4">
                <form @submit.prevent="login">
                    <div class="form-group">
                        <label for="usuario_username">Nombre de usuario:</label>
                        <input type="text" class="form-control" id="usuario_username" v-model="usuario.username">
                    </div>
                    <div class="form-group">
                        <label for="usuario_password">Password:</label>
                        <input type="password" class="form-control" id="usuario_password" v-model="usuario.password">
                    </div>
                    <div class="form-group">
                        <button type="submit" class="btn btn-primary">Ingresar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import authService from '../services/auth-service'

export default {
    data() {
        return {
            usuario: {}
        }
    },
    methods: {
        login() {
            authService.autenticar(this.usuario.username, this.usuario.password).then(response => {
                this.$router.push({ name: 'dashboard' });
            });
        }
    }
}
</script>
