# Genetic Art

I built a Windows desktop experiment that approximates an image with translucent triangles. It copies the best candidate, mutates the copies, renders them, and keeps the candidate with the lowest image error.

## Examples

![IMG_6863](https://github.com/user-attachments/assets/c931046f-15e3-490f-b014-cd5e60b51e33)

![IMG_6861](https://github.com/user-attachments/assets/c227ace3-fe9f-44a0-b152-03044844dc89)

![IMG_6846](https://github.com/user-attachments/assets/6b1306d2-5fbf-4e88-8ba9-5479de6f04f8)

These are the original images attached to this repository. The reproducible checkpoint export below is the better view of the search process.

### Checkpoint export

The optional `--export` mode saves the best candidate at generations 0, 25, 100, 250, 500, and 1,000. It uses a fixed seed and runs on Windows through the repository's GitHub Actions workflow. The workflow artifact contains the PNG checkpoints and `metrics.csv`.

## How it works

1. The form loads a target image embedded in `Form1.resx`.
2. Each candidate is a list of colored triangles, capped at **60** by default.
3. Mutations add a triangle, remove one, or change its points and color.
4. `GetError()` compares rendered bitmap bytes with the target and sums squared differences, normalized by image area.
5. The trainer keeps the best candidate and uses it as the starting point for the next batch.

This is a mutation-and-selection search. The current trainer does not cross over two parent images. Its error value is a pixel-buffer objective, not a perceptual similarity percentage.

## Run locally

This project targets **`net6.0-windows`** with **Windows Forms**. Run it on Windows with a compatible .NET SDK and Windows Desktop runtime.

```sh
dotnet run --project "Genetic Art/Genetic Art.csproj" -c Release
```

Press **Do** to run 1,000 training iterations and update the candidate images. To change the target, edit the `Original.Image` resource in the Windows Forms designer. Mutation settings and the triangle limit live in `TriangleArtConstants.cs`.

## Code guide

| File in `Genetic Art/` | Responsibility |
| --- | --- |
| `Form1.cs` | Target image, candidate grid, training button |
| `GeneticArtTrainer.cs` | Candidate mutation and best-candidate selection |
| `TriangleArt.cs` | Image rendering, mutation, pixel error |
| `Triangle.cs` | Triangle geometry and color |
| `TriangleArtConstants.cs` | Search settings |

## Current limitations

Training runs on the UI thread, so the form can be unresponsive during a batch. The trainer now keeps at least one triangle, disposes temporary drawing resources, releases bitmap locks after error calculation, and disposes replaced preview images. The optional export uses a repeatable seed and records milestone images.

The project compiled with Windows targeting enabled during a local macOS check. The Windows Forms UI still has not been rerun here, so a new visual recording needs a Windows desktop run.
