# Blackbird.io Zendesk Chat [Beta]

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

Use Zendesk Chat in Blackbird to retrieve chat records, create offline messages, manage visitor profiles, and manage bans.

## Connection

1. Add a new Zendesk Chat connection in Blackbird and give it a name.
2. Enter your Zendesk account's **Subdomain**. For example, enter `example` for `example.zendesk.com`.
3. Sign in to Zendesk Chat and authorize Blackbird.

This connector uses the legacy Zopim Chat REST API. Zendesk documents a transition to an account-specific endpoint in its [Live Chat API reference](https://developer.zendesk.com/api-reference/live-chat/introduction/).

## Actions

### Chats

- **List chats** Search for chat records and output the results.
- **Get chat** Get the details of a selected chat.
- **Create chat** Create an offline message with the visitor's details.
  - **Visitor phone** Phone number to include with the visitor details.
  - **Timestamp** Supply the message time in Unix seconds. The action marks this field optional, but Zendesk documents it as required.
- **Delete chat** Delete a selected chat record.

### Visitors

- **Create visitor** Create a visitor profile with contact details and notes.
- **Get visitor** Get the profile for a visitor by ID.
- **Update visitor** Update the supplied contact details or notes for a visitor.
  - **Phone** New phone number for the visitor.
  - **Notes** New notes for the visitor profile.
  - **Name** New name for the visitor.
  - **Email** New email address for the visitor.

### Bans

- **List bans** Search for visitor and IP address bans.
- **List banned IP addresses** Search for banned IP addresses and output the addresses.
- **Get ban** Get the details of a selected ban.
- **Ban visitor** Block a visitor by ID and record the reason for the ban.
- **Ban IP** Block an IP address and record the reason for the ban.
- **Delete ban** Remove a selected visitor or IP address ban.


## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
