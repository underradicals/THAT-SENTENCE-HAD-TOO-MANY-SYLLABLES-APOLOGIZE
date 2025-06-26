import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  vite: {
    server: {
      port: 8000,
      host: '0.0.0.0',
      strictPort: true,
      https: {
        key: 'D:\\certs\\cert.key',
        cert: 'D:\\certs\\cert.crt'
      }

    }
  },
  title: "D2App Docs",
  description: "Documentation for D2App",
  themeConfig: {
    search: {
      provider: 'local'
    },
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Project', link: '/pm' },
      { text: 'Design', link: '/design' },
      { text: 'Architecture', link: '/architecture' },
      { text: 'API', link: '/api' },
      { text: 'Guides', link: '/guides' },
      { text: 'Team', link: '/team' }
    ],

    sidebar: {
      '/pm/': [
        {
          text: 'Introduction',
          items: [
            { text: 'What is PM?', link: '/pm/index' },
            { text: 'Getting Started', link: '/pm/getting-started' },
            { text: 'Project Charter', link: '/pm/project-charter' },
          ]
        }
      ],
      '/design/': [
        {
          text: 'Introduction',
          items: [
            { text: 'Why Deliverables?', link: '/design/index' },
            { text: 'Getting Started', link: '/design/getting-started' }
          ]
        }
      ],
      '/architecture/': [
        {
          text: 'Introduction',
          items: [
            { text: 'Fundamentals', link: '/architecture/index' },
            { text: 'Getting Started', link: '/architecture/getting-started' }
          ]
        }
      ],
      '/api/': [
        {
          text: 'Introduction',
          items: [
            { text: 'What is an API?', link: '/api/index' },
            { text: 'Getting Started', link: '/api/getting-started' }
          ]
        }
      ],
      '/guides/': [
        {
          text: 'Introduction',
          items: [
            { text: 'What are patterns?', link: '/guides/index' },
            { text: 'Getting Started', link: '/guides/getting-started.md' }
          ]
        }
      ]
    },

    socialLinks: [
      { icon: 'github', link: 'https://github.com/underradicals' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ],

    footer: {
      message: 'Released under the MIT License.',
      copyright: 'Copyright © 2025 Underradicals Group'
    },
    aside: true,
    outline: 2
  },
  markdown: {
    math: true
  }
})
