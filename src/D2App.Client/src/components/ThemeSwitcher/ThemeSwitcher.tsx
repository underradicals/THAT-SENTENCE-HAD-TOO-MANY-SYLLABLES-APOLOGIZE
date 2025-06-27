import { useState, useEffect } from 'react';

import '@/components/ThemeSwitcher/ThemeSelector.scss';


function ThemeSelector() {
  const [theme, setTheme] = useState('light');

  const handleThemeChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedTheme = event.target.value;
    setTheme(selectedTheme);
    localStorage.setItem('theme', selectedTheme);
  }

  useEffect(() => {
    const pastTheme = localStorage.getItem('theme');
    if (!pastTheme) {
      localStorage.setItem('theme', theme);
    } else {
      setTheme(pastTheme);
    }
  }, []);

  return (
    <form>
      <select name="theme" id="theme" onChange={handleThemeChange} value={theme}>
        <button>
          <selectedcontent></selectedcontent>
        </button>

        <option value="light">Light</option>
        <option value="dark">Dark</option>
        <option value="system">System</option>
      </select>
    </form>
  );
}


export default ThemeSelector;