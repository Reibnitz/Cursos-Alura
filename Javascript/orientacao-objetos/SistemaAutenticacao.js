// Para ser autenticável, o objeto precisa ter a propriedade 'senha'

export class SistemaAutenticacao {
    static login(usuario, senha){
        if (SistemaAutenticacao.ehAutenticavel(usuario)){
            return usuario.autenticar(senha);
        } else {
            return false;
        }
    }

    static ehAutenticavel(usuario){
        return "autenticar" in usuario; // Verifica se a chave (método, propriedade) 'autenticar' existe no objeto 'usuario'.
    }
}