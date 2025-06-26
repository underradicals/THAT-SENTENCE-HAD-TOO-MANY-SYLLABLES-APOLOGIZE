---
layout: page
---

<script setup>
import {
  VPTeamPage,
  VPTeamPageTitle,
  VPTeamMembers
} from 'vitepress/theme'

const members = [
  {
    avatar: 'https://www.github.com/underradicals.png',
    name: 'Joseph Burton',
    title: 'Creator',
    links: [
      { icon: 'github', link: 'https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ]
  },
  {
    avatar: 'https://www.github.com/underradicals.png',
    name: 'Joseph Burton',
    title: 'Project Manager',
    links: [
      { icon: 'github', link: 'https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ]
  },
  {
    avatar: 'https://www.github.com/underradicals.png',
    name: 'Joseph Burton',
    title: 'System Designer',
    links: [
      { icon: 'github', link: 'https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ]
  },
  {
    avatar: 'https://www.github.com/underradicals.png',
    name: 'Joseph Burton',
    title: 'System Architecture',
    links: [
      { icon: 'github', link: 'https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ]
  },
  {
    avatar: 'https://www.github.com/underradicals.png',
    name: 'Joseph Burton',
    title: 'Software Developer',
    links: [
      { icon: 'github', link: 'https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ]
  },
  {
    avatar: 'https://www.github.com/underradicals.png',
    name: 'Joseph Burton',
    title: 'Database Developer / Administrator',
    links: [
      { icon: 'github', link: 'https://github.com/underradicals/THAT-SENTENCE-HAD-TOO-MANY-SYLLABLES-APOLOGIZE' },
      { icon: 'twitter', link: 'https://x.com/underradicals' }
    ]
  },
]
</script>

<VPTeamPage>
  <VPTeamPageTitle>
    <template #title>
      Our Team
    </template>
    <template #lead>
      We have an amazing and humble team here at underradicals, namely...Me! 
    </template>
  </VPTeamPageTitle>
  <VPTeamMembers :members />
</VPTeamPage>
