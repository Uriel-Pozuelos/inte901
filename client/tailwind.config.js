/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      colors: {
        primary: "#F5F5F5",
        secondary: "#da8efa",
        accent: "#7768bb",
        neutral: "#B1D4FF",
        "base-100": "#B1D4FF",
        background: "#66CCCC",
        info: "#3399FF",
        success: "#F78DB1",
        warning: "#515d8c",
        error: "#E14E64",
      },
    },
  },
  plugins: [],
};
