const app = new Vue({
    el: "#app",
    data: {
      editandoLivro: null,
      livros: [],
      novoLivro: {
          Id: "",
          Nome: "",
          Autor: "",
      }
    },
    methods: {
      deletarLivro(livro) {
        fetch("http://localhost:8080/api/Livro", {
            body: JSON.stringify(livro),
            method: "DELETE",
            headers: {
              "Content-Type": "application/json",
            },
        })
        .then(() => {
            var index = this.livros.indexOf(livro);
            this.livros.splice(index, 1);
        })
      },
      atualizarLivro(livro) {
        fetch("http://localhost:8080/api/Livro",{
          body: JSON.stringify(livro),
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
        })
        .then(() => {
          this.editandoLivro = null;
        })
      },
      novoLivro(livro) {
        fetch("http://localhost:8080/api/Livro",{
          body: JSON.stringify(livro),
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
        })
        .then(response => response.json())
        .then((data) => {
            this.livros.push(data);
          })
      }
    },
    mounted() {
      fetch("http://localhost:8080/api/Livro")
        .then(response => response.json())
        .then((data) => {
          this.livros = data;
        })
    },
    template: `
    <div>
      <table v-for="livro in livros">
        <div v-if="editandoLivro === livro.id">
          <input v-on:keyup.13="atualizarLivro(livro)" v-model="livro.Nome" />
          <input v-on:keyup.13="atualizarLivro(livro)" v-model="livro.Autor" />
          <button v-on:click="atualizarLivro(livro)">save</button>
        </div>
        <div v-else>
          <button v-on:click="editandoLivro = livro.id">edit</button>
          <button v-on:click="deletarLivro(livro)">x</button>
          <b>Livro:</b> {{livro.Nome}} <b>Autor:</b> {{livro.Autor}}
        </div>
      </table>
        
      <h1>Criar novo livro:</h1>
      <input v-model="novoLivro.Nome" />
      <input v-model="novoLivro.Autor" />
      <button v-on:click="novoLivro(novoLivro)">save</button>
    </div>
    `,
});