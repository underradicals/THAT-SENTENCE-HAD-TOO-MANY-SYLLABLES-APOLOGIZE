---
title: What Is Cors
lang: en-US
aside: true
layout: doc
---

# What is CORS?

## Introduction

CORS which stands for **Cross-Origin Resource Sharing** is a protocol built on top of the HTTP protocol that allows sharing responses across origins. Origins are a fundamental aspect of the web's security model which is colloquially known as `Same-Origin Policy`.

You see, [User-Agents](../glossary/http.md) often have to execute actions on behalf of [remote parties](../glossary/http.md): Without **SOP** there do not exist any layers of isolation. Javascript from `attacker.com` can read data at `mail.company.com`.

## What is an Origin

An **Origin** is comprised of three parts:

- Schema: `http`, `https`, `file`, and `data`
- Host: `api.example.com`, `localhost`, `192.168.1.1`
  - Top Level Domain: `com`, `io`, `co.uk`
  - Domain: `google`, `facebook`
  - Sub Domain: `www`, `api`
- Port: `80`, `443`, `3000`

> Example Origin is something like: `https://example.com:443`

::: tip URL Parts
There are other parts of a `Host` that are **NOT** considered when checking if two actors share the same origin. For example:

> https://example.com:443/blog/article/slug?id=1234&lang=en#dayone

- Path: `/blog/article/slug`
- Query Parameters: `?id=1234&lang=en`
- Fragment: `#dayone`
  :::

The CORS protocol consists of a set of headers that indicates whether a response can be shared cross-origin. For an quick definition of what these headers are checkout the [glossary](../glossary/cors.md).

## Other Terminology

The Spec also distinguishes between `ORIGIN`, `SITE` and `HOST`:

- Origin: This is a tuple: (schema, host, port).
  | URL | Origin |
  | ------------------------- | ------------------------------- |
  | `https://example.com:443` | `("https", "example.com", 443)` |
  | `http://example.com:80` | `("http", "example.com", 80)` |
  | `https://192.168.1.1:443` | `("https", "192.168.1.1", 443)` |

- Site: This is a _registrable domain_ $+$ it's schema; you disregard subdomains and the port.
  | URL | Site |
  | -------------------------- | ------------------------------------------ |
  | `https://api.example.com` | `https://example.com` |
  | `https://example.com:443` | `https://example.com` |
  | `http://sub.example.co.uk` | `http://example.co.uk` |
  | `https://192.168.1.1` | `https://192.168.1.1` (IP is its own site) |
  | `file:///` | `null` (no site) |

- Host: This is the _domain name_ or _IP address_ in the URL.
  | URL | Host |
  | ------------------------- | ----------------- |
  | `https://api.example.com` | `api.example.com` |
  | `https://example.com` | `example.com` |
  | `https://192.168.1.1` | `192.168.1.1` |
  | `file:///path/to/file` | _null_ |

::: tip
A registrable domain is the highest level domain a user can register, like example.com, determined using the [Public Suffix List](https://publicsuffix.org/).
:::

## Determine Effective Domain of Origin

```js
class Origins {
  constructor() {
    this.schema = null;
    this.port = null;
    this.host = null;
    this.domain = null;
  }

  breakdown(url) {
    const urlPattern = /^(https?):\/\/([^:\/]+)(?::(\d+))?(.*)$/;
    const match = url.match(urlPattern);
    if (!match) {
      throw new Error("Invalid URL format");
    }
    this.schema = match[1];
    this.host = match[2];
    this.port = match[3]
      ? parseInt(match[3], 10)
      : this.schema === "https"
      ? 443
      : 80;

    this.getDomain();
  }

  getDomain() {
    if (!this.host) {
      throw new Error("Host is not set. Please call breakdown() first.");
    }
    const parts = this.host.split(".");
    if (parts.length < 2) {
      throw new Error("Invalid host format");
    }
    this.domain = parts.slice(-2).join(".");
    return this.domain;
  }
}
```

## Terminology

#### **Excerpts from [RFC 2616](https://datatracker.ietf.org/doc/html/rfc2616#section-1.3)**

- `Connection` A transport layer virtual circuit established between two programs
  for the purpose of communication.

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

- `User Agent` The client which initiates a request. These are often browsers,
  editors, spiders (web-traversing robots), or other end user tools.

- `Server` An application program that accepts connections in order to
  service requests by sending back responses. Any given program may
  be capable of being both a client and a server; our use of these
  terms refers only to the role being performed by the program for a
  particular connection, rather than to the program's capabilities
  in general. Likewise, any server may act as an origin server,
  proxy, gateway, or tunnel, switching behavior based on the nature
  of each request.

- `Origin Server` The server on which a given resource resides or is to be created.
