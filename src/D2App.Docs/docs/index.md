---
# https://vitepress.dev/reference/default-theme-home-page
layout: home

hero:
  name: "D2"
  text: "Information System"
  tagline: Data is not made for the Web. It's a place for Information.
  image:
    dark: "d2-dark.svg"
    light: "d2-light.svg"
    alt: "destiny 2 logo"
  actions:
    - theme: brand
      text: D2 Viewer
      link: https://localhost:3001
    - theme: alt
      text: D2 Swagger
      link: https://localhost:5000/swagger
    - theme: alt
      text: GitHub
      link: https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE
    - theme: alt
      text: PM Home
      link: https://github.com/users/underradicals/projects/7/views/1?template_dialog_tab=featured&system_template=kanban

features:
  - icon: 💼
    title: PMD
    details: You can find all the Deliverables for the D2 Project here.
    link: "/pm"
    linkText: "Deliverables"
  - icon: ⚙️
    title: Patterns
    details: Here you will find any and all patterns used during the development of the D2 Project
    link: "/guides"
    linkText: "Patterns"
  - icon: 🖥️
    title: API
    details: Here you will find all documentation for the D2 public API.
    link: "/api"
    linkText: "API Docs"

footer: false
---
