# ognjendrazic.com

Source for my personal site, built with [Vite+](https://viteplus.dev) and deployed to GitHub Pages at <https://ognjendrazic.com>.

```sh
npm install
npm run dev      # local dev server with hot reload
npm run check    # format, lint and type checks
npm run build    # production build into dist/
npm run preview  # serve the production build locally
```

Every push to `main` builds and deploys through `.github/workflows/deploy.yml`.
Static files that must be copied as-is (`CNAME`, `404.html`) live in `public/`.
