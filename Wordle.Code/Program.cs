using Wordle.Code;

var wordPicker = new WordPicker();
var reader = new ConsoleReader();
var player = new Player(reader);
var writer = new ConsoleWriter();

var answerList = File.ReadAllLines("../../../../Wordle.Code/AnswerList.txt");
var gameWord = wordPicker.Pick(answerList);

var clue = new ClueGenerator(gameWord);
var controller = new GameController(clue, player, writer);

controller.Run();