
// Length of the command
const int CMD_LEN = 2;
// Command buffer
char cmd[CMD_LEN];

// length of the message 
const int MSG_LEN = 80;
// Message buffer
char msg[MSG_LEN];

enum Command {SET_BINARY = 0, SET_ANALOG, QUERY};
enum BinarySet {OFF = 0, ON};

const int BINARY_PIN = 13;
const int ANALOG_PIN = 11;

int CurrentState = 0; // Current state is `Off` initially
int AnalogLevel = 0; // Analog level is `0` initially

void setup() {
  pinMode(BINARY_PIN,OUTPUT);
  pinMode(ANALOG_PIN,OUTPUT);
  Serial.begin(9600);
}

void SetBinaryPin(char *set)
{
  switch(set[1])
  {
    case OFF:
      sprintf(msg, "SetBinaryPin - set mode: %d \n", LOW);
      CurrentState = LOW;
      break;
    case ON:
      sprintf(msg, "SetBinaryPin - set mode: %d \n", HIGH);
      CurrentState = HIGH;
      break;
    default:
      sprintf(msg, "Error: SetBinaryPin - invalid set mode: %d \n", set[1]);
      break;
  }
  Serial.println(msg);
}

void SetAnalogPin(char *set)
{
  if (set[1] < 0 || set[1] > 5)
  {
    sprintf(msg, "Error: SetAnalogPin - invalid set mode: %d \n", set[1]);
  }
  else 
  {
    sprintf(msg, "SetAnalogPin - set level: %d \n", set[1]);
    AnalogLevel = set[1];
  }
   Serial.println(msg);
}

void QueryReply()
{
  sprintf(msg, "CurrentState = %d, AnalogLevel = %d \n", CurrentState, AnalogLevel);
  Serial.println(msg);
}

void loop() {

  // Command from the controller
  if (Serial.available() > 0)
  {
    int inComingBytes = Serial.readBytes(cmd, CMD_LEN);

    switch(cmd[0])
    {
      case SET_BINARY:
        SetBinaryPin(cmd);
        break;
      case SET_ANALOG:
        SetAnalogPin(cmd);
        break;
      case QUERY:
        QueryReply();
        break;
      default:
        Serial.println("Error: command unknown \n");
    } // End switch(cmd[0])
  } // End if (Serial.available() > 0)
}
