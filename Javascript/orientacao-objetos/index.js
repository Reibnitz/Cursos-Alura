// import {ContaCorrente} from "./Conta/ContaCorrente.js"
// import {ContaPoupanca} from "./Conta/ContaPoupanca.js"
import {Gerente} from "./Funcionario/Gerente.js"
import {Diretor} from "./Funcionario/Diretor.js"
import {SistemaAutenticacao} from "./SistemaAutenticacao.js"
import { Cliente } from "./Cliente.js";

const diretor = new Diretor("Diego", 10000, 44455566607);
const gerente = new Gerente("Geraldo", 5000, 77788899907);
const cliente = new Cliente("Cláudia", 99988877707, "password1234");

diretor.cadastrarSenha("123456789");
gerente.cadastrarSenha("1234");

var diretorEstaLogado = SistemaAutenticacao.login(diretor, "123456789");
var gerenteEstaLogado = SistemaAutenticacao.login(gerente, "senhaErrada");
var clienteEstaLogado = SistemaAutenticacao.login(cliente, "password1234");

console.log(diretorEstaLogado, gerenteEstaLogado, clienteEstaLogado);