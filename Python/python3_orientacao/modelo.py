class Programa:
    def __init__(self, nome, ano):
        self._nome = nome.title()
        self._ano = ano
        self._likes = 0

    def dar_likes(self):
        self._likes =+ 1

    @property
    def nome(self):
        return self._nome

    @property
    def ano(self):
        return self._ano

    @property
    def likes(self):
        return self._likes


class Filme(Programa): # Define Programa como sendo a classe-mãe
    def __init__(self, nome, ano, duracao):
        super().__init__(nome, ano) # Função super() chama a classe-mãe. Nesse caso, __init__ não usa self
        self._duracao = duracao

    @property
    def duracao(self):
        return self._duracao

    def __str__(self): # Define a saída de print(self)
        return f"Nome: {self._nome} - Ano: {self._ano} - Duração: {self._duracao} min. - Likes: {self._likes}"


class Serie(Programa):
    def __init__(self, nome, ano, temporadas):
        super().__init__(nome, ano)
        self._temporadas = temporadas

    @property
    def temporadas(self):
        return self._temporadas

    def __str__(self):
        return f"Nome: {self._nome} - Ano: {self._ano} - Temporadas: {self._temporadas} - Likes: {self._likes}"

class Playlist:
    def __init__(self, nome, programas):
        self.nome = nome
        self._programas = programas

    def __getitem__(self, item): # Faz com que a classe Playlist seja iterável, retornando valores da lista de self._programas[]
        return self._programas[item]

    def __len__(self):
        return len(self._programas)


vingadores = Filme("vingadores guerra infinita", 2020, 240)
witcher = Serie("the witcher", 2021, 2)
rbw = Serie("raised by wolves", 2021, 2)
got = Serie("game of thrones", 2013, 8)

lista_de_programas = [vingadores, witcher, rbw]
playlist_criada = Playlist("Nome da playlist", lista_de_programas)

print(f"Essa playlist contém {len(playlist_criada)} itens:")
for programa in playlist_criada:
    print(programa)