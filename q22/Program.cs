/* Questão 22 - Questão Operacional - Nível Meio-Oficial
 *
 * Você precisa implementar um controlador de robo para achar a saída de um labirinto.
 * Porém o robo tem uma habilidade especial: Ele pode clonar-se quantas vezes você desejar.
 *
 * Para isso implemente a classe Controller onde você recebera os robos que precisa de controle.
 * Você tem vários métodos disponíveis da classe CellRobot (que não pode ser alterada), são eles:
 *
 * WallUp { get; } => Indica se existe um outro Robo ou parede logo acima.
 * WallDown { get; } => Indica se existe um outro Robo ou parede logo abaixo.
 * WallLeft { get; } => Indica se existe um outro Robo ou parede logo a esquerda.
 * WallRigth { get; } => Indica se existe um outro Robo ou parede logo a direita.
 *
 * MoveUp() => Move-se para cima, se possível.
 * MoveDown() => Move-se para baixo, se possível.
 * MoveLeft() => Move-se para esquerda, se possível.
 * MoveRigth() => Move-se para direita, se possível.
 *
 * CloneUp() => Clona um novo robo acima, se possível.
 * CloneDown() => Clona um novo robo abaixo, se possível.
 * CloneLeft() => Clona um novo robo a esquerda, se possível.
 * CloneRigth() => Clona um novo robo a direita, se possível.
 *
 * Aperte barra de espaço para que o controlador atue.
 * Sua implementação deve ser na Classe Controller e não deve alterar as outras classes e arquvios.
 */

using Pamella;

var view = new Maze();
App.Open(view);