/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{js,jsx,ts,tsx}"],
  theme: {
    extend: {
      height: {
        '700': '800px',
      },
      screens: {
        sm: "640px",
        md: "768px",
        lg: "1024px",
        xl: "1280px",
        "2xl": "1536px",
      },
      colors: {
        'title':'rgb(52, 71, 103)',
        'description':'rgb(123, 128, 154)',
        'color-nav':'#343767',
        'bg_navbar':'rgba(255, 255, 255, 0.8)',
      },
    },
  },
  plugins: [],
}
