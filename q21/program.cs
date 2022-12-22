// Questão 1.Ao chegar em uma fila, um cliente pode decidir permanecer ou desistir se estiver impaciente.
// Você receberá um vetor de paciência onde a primeira posição do vetor é a paciência da primeira pessoa a chegar na fila.
// Assim a segunda posição do vetor é a paciência da segunda pessoa que chega na fila. E assim por diante.
// Se uma pessoa com paciência 2 chega numa fila com mais de 2 pessoas ela desiste e não entra na fila.
// Seu trabalho é escrever uma função que recebe esse vetor de paciência e retorna o tamanho final da fila.
// Exemplos:
// [2, 2, 0, 2, 2, 10]
// A fila começa vazia, a primeira pessoa chega com paciência 2 e como 0 < 2, ela entra na fila. Agora temos 1 pessoa na fila.
// A segunda pessoa também entra na fila. Agora temos 2 pessoas na fila.
// A terceira pessoa é impaciente e não entra na fila. Ainda temos 2 pessoas na fila.
// A quarta pessoa entra na fila, pois 2 (tamanho da fila) não é maior que 2 (paciência do cliente). Temoa 3 pessoas na fila.
// A quinta pessoa na fila tem paciência 2, ela não entra na fila pois a fila tem tamanho 3 maior que sua paciência 2.
// A última pessoa é muito paciente (10) e acaba entrando na fila. Resultado final 4 pessoas na fila.

int[] patience = new int[]
{
    0, 0, 1, 1, 2, 2, 3, 3, 4, 4
};

queueSize(patience);

int queueSize(int[] queue)
{
    return -1;
}

// Questão 2.A respeito das pessoas da lista de paciência, use Linq para responder as seguintes perguntas:
// a) A maior paciência.
// b) A menor paciência.
// c) Quantos clientes tem mais de 2 de paciência.
// d) Qual grupo é maior? Os pacientes (>5), os impaciente (<2) ou os normais (2 a 5).
// Lembre-se de responder com Linq e não apenas o número.

// Questão 3. Implemente a função demitir que faz o seguinte:
// Faz com que o Chefe do colaborador demitido se torne chefe de todos os colaboradores que o colaborador demitido era chefe.
// Exemplo
//     A
//     |          A é chefe de B e
//     B          B é chefe de C,
//    /|\         D e E.
//   C D E
// Quando B é demitido o seguinte acontece:
//     A
//    /|\         Agora A é chefe
//   C D E        de C, D e E.

public class Colaborador
{
    public string Nome { get; set; }
    public Colaborador Chefe { get; set; }
    public List<Colaborador> Subordinados { get; set; } = new List<Colaborador>();

    public void Demitir()
    {
        
    }
}
