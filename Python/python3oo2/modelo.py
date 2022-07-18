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

    def __str__(self): # Função __str__ define uma representação textual ao objeto que sairá dando print(objeto).
        return f"Nome: {self._nome}\nAno: {self._ano}\nLikes: {self._likes}"


class Filme(Programa): # Define Programa como sendo a classe-mãe
    def __init__(self, nome, ano, duracao):
        super().__init__(nome, ano) # Função super() chama a classe-mãe. Nesse caso, __init__ não usa self
        self._duracao = duracao

    @property
    def duracao(self):
        return self._duracao

    def __str__(self):
        return f"Nome: {self._nome}\nAno: {self._ano}\nDuração: {self._duracao} min.\nLikes: {self._likes}"


class Serie(Programa):
    def __init__(self, nome, ano, temporadas):
        super().__init__(nome, ano)
        self._temporadas = temporadas

    @property
    def temporadas(self):
        return self._temporadas

    def __str__(self):
        return f"Nome: {self._nome}\nAno: {self._ano}\nTemporadas: {self._temporadas}\nLikes: {self._likes}"

class Playlist:
    def __init__(self, nome, lista):
        self.nome = nome
        super()__init__(lista)


vingadores = Filme("vingadores guerra infinita", 2020, 240)
witcher = Serie("the witcher", 2021, 2)
rbw = Serie("raised by wolves", 2021, 2)

lista_de_programas = [vingadores, witcher, rbw]
playlist = Playlist("Nome da playlist", lista_de_programas)

print("oi")
for programa in playlist:
    print(programa)