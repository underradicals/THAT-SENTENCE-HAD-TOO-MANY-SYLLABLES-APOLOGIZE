---
title: HTTP Definitions
lang: en-US
aside: true
layout: doc
---

# HTTP Definitions

- `Connection` A transport layer virtual circuit established between two programs for the purpose of communication.

- `Message` The basic unit of HTTP communication, consisting of a structured
  sequence of octets matching the syntax defined in [section 4](https://datatracker.ietf.org/doc/html/rfc2616#section-4) and
  transmitted via the connection.

- `Resource` A network data object or service that can be identified by a URI,
  as defined in [section 3.2.](https://datatracker.ietf.org/doc/html/rfc2616#section-3.2) Resources may be available in multiple
  representations (e.g. multiple languages, data formats, size, and
  resolutions) or vary in other ways.

- `Request` An HTTP request message, as defined in [section 5.](https://datatracker.ietf.org/doc/html/rfc2616#section-5)

- `Response` An HTTP response message, as defined in [section 6.](https://datatracker.ietf.org/doc/html/rfc2616#section-6)

- `Client` A program that establishes connections for the purpose of sending
  requests.

- `User Agent` The client which initiates a request. These are often browsers, editors, spiders (web-traversing robots), or other end user tools. A User Agent is any software that acts on behalf of the user to interact with remote web resources. It initiates HTTP(S) requests, parses responses, and renders or processes content.
  | Type | Example | Description |
  | ---------------------- | --------------------------------------- | --------------------------------------------------------------------------------------- |
  | **Web Browsers** | Chrome, Firefox, Safari, Edge, Opera | Most common type of UA. Handles rendering HTML, running JavaScript, enforcing SOP, etc. |
  | **Mobile Browsers** | Chrome for Android, Safari on iOS | Browser engine embedded in mobile apps. |
  | **Command-line Tools** | `curl`, `wget`, `httpie` | UAs for programmatic or manual request testing. Can follow redirects, download files. |
  | **API Clients** | Postman, Insomnia | Developer tools to interact with APIs. Often set custom headers, auth tokens. |
  | **Headless Browsers** | Puppeteer (headless Chrome), Playwright | Programmatic browser environments for scraping, automation, or testing. |
  | **Embedded UAs** | WebViews in Android/iOS apps | Limited browser instances used inside native apps. |
  | **Search Crawlers** | Googlebot, Bingbot | Automated UAs that index websites for search engines. |
  | **Game Clients** | Steam client, in-game web views | Some games embed browsers for in-game stores or login flows. |
  | **Email Clients** | Outlook, Thunderbird, Apple Mail | These act as UAs when rendering HTML emails and fetching embedded resources. |

- `Remote Parties` A Remote Party is any server, service, or origin that provides content or instructions to a user agent. It represents the external source of code, data, or directives.
  | Role | Example | Description |
  | ---------------------------- | -------------------------------------------------- | -------------------------------------------------------------------------------- |
  | **Web Servers** | `example.com`, `api.example.com`, `cdn.google.com` | Hosts HTML, JavaScript, images, and other content. Responds to UA requests. |
  | **API Backends** | `api.twitter.com`, `api.openai.com` | Serve JSON or binary responses to frontends or tools. Often REST or GraphQL. |
  | **OAuth Identity Providers** | `accounts.google.com`, `login.microsoftonline.com` | Perform user authentication and redirect UAs back to relying parties. |
  | **CDNs** | `cdnjs.cloudflare.com`, `cdn.jsdelivr.net` | Distribute static assets like JavaScript libraries globally. |
  | **Ad Networks / Trackers** | `doubleclick.net`, `facebook.net` | Serve ads or analytics scripts; may attempt to inject or execute code on client. |
  | **Malicious Sites** | `evil.com`, phishing domains | Attempt to exploit UA behavior to attack users or other origins. |

- `Server` An application program that accepts connections in order to
  service requests by sending back responses. Any given program may
  be capable of being both a client and a server; our use of these
  terms refers only to the role being performed by the program for a
  particular connection, rather than to the program's capabilities
  in general. Likewise, any server may act as an origin server,
  proxy, gateway, or tunnel, switching behavior based on the nature
  of each request.

- `Origin Server` The server on which a given resource resides or is to be created.

- `Entity`
  The information transferred as the payload of a request or
  response. An entity consists of metainformation in the form of
  entity-header fields and content in the form of an entity-body, as
  described in section 7.

- `Representation`
  An entity included with a response that is subject to content
  negotiation, as described in section 12. There may exist multiple
  representations associated with a particular response status.

- `Content Negotiation`
  The mechanism for selecting the appropriate representation when
  servicing a request, as described in section 12. The
  representation of entities in any response can be negotiated
  (including error responses).

- `Variant`
  A resource may have one, or more than one, representation(s)
  associated with it at any given instant. Each of these
  representations is termed a `variant`. Use of the term `variant`
  does not necessarily imply that the resource is subject to content
  negotiation.

- `Proxy`
  An intermediary program which acts as both a server and a client
  for the purpose of making requests on behalf of other clients.
  Requests are serviced internally or by passing them on, with
  possible translation, to other servers. A proxy MUST implement
  both the client and server requirements of this specification. A
  "transparent proxy" is a proxy that does not modify the request or
  response beyond what is required for proxy authentication and
  identification. A "non-transparent proxy" is a proxy that modifies
  the request or response in order to provide some added service to
  the user agent, such as group annotation services, media type
  transformation, protocol reduction, or anonymity filtering. Except
  where either transparent or non-transparent behavior is explicitly
  stated, the HTTP proxy requirements apply to both types of
  proxies.

- `Gateway`
  A server which acts as an intermediary for some other server.
  Unlike a proxy, a gateway receives requests as if it were the
  origin server for the requested resource; the requesting client
  may not be aware that it is communicating with a gateway.

- `Tunnel`
  An intermediary program which is acting as a blind relay between
  two connections. Once active, a tunnel is not considered a party
  to the HTTP communication, though the tunnel may have been
  initiated by an HTTP request. The tunnel ceases to exist when both
  ends of the relayed connections are closed.

- `Cache`
  A program's local store of response messages and the subsystem
  that controls its message storage, retrieval, and deletion. A
  cache stores cacheable responses in order to reduce the response
  time and network bandwidth consumption on future, equivalent
  requests. Any client or server may include a cache, though a cache
  cannot be used by a server that is acting as a tunnel.

- `Cacheable`
  A response is cacheable if a cache is allowed to store a copy of
  the response message for use in answering subsequent requests. The
  rules for determining the cacheability of HTTP responses are
  defined in section 13. Even if a resource is cacheable, there may
  be additional constraints on whether a cache can use the cached
  copy for a particular request.
