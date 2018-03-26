# Alexa Dishwasher Status
Ever wonder if the dishes within your dishwasher are clean or dirty? And kick yourself after you 
load dirty dishes when it was clean all along?

This is an Alexa skill that tracks the dishwasher status, clean or dirty, using Azure to both process 
requests and maintain state. It leverages AlexaSkillsKit.Lib to map speechlets and intents. 

## Skill Overview
The Alexa skill handles the following intents:

* **Retrieve State**: responds with or confirms the current status, such as clean or dirty
* **Update State**: sets the state directly to clean or dirty
* **Unload**: sets the state to dirty.
* **Start**: sets the state to clean

## Getting Started

### Prerequisites
You will need the following:

* Azure account
* Azure functions instance
* Azure table storage instance (i.e. basic table API or Cosmos Table API)
* Alexa developer account

### Installation

Import skill schema (TBD), enable developmment, download Azure publish profile, update Azure settings keys, etc.


