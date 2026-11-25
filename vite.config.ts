import { defineConfig } from 'vite-plus';

export default defineConfig({
  // Served from the root of ognjendrazic.com, so no base path is needed.
  base: '/',
  build: {
    outDir: 'dist',
  },
  lint: {
    ignorePatterns: ['dist/**'],
  },
  fmt: {
    ignorePatterns: ['dist/**'],
    singleQuote: true,
  },
});
