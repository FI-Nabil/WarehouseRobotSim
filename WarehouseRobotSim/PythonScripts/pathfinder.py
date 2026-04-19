import json
import sys
from collections import deque

def find_path(grid, start, end):
    rows = len(grid)
    cols = len(grid[0])
    queue = deque([(tuple(start), [start])])
    visited = {tuple(start)}

    while queue:
        (x, y), path = queue.popleft()
        if [x, y] == end:
            return path

        # Directions: Up, Down, Left, Right
        for dx, dy in [(0, 1), (1, 0), (0, -1), (-1, 0)]:
            nx, ny = x + dx, y + dy
            if 0 <= nx < rows and 0 <= ny < cols and grid[nx][ny] == 0 and (nx, ny) not in visited:
                visited.add((nx, ny))
                queue.append(((nx, ny), path + [[nx, ny]]))
    return None

if __name__ == "__main__":
    # Read data sent from C#
    try:
        input_data = json.loads(sys.stdin.read())
        grid = input_data['grid']
        start = input_data['start']
        end = input_data['end']

        result_path = find_path(grid, start, end)
        
        if result_path:
            print(json.dumps({"status": "success", "path": result_path}))
        else:
            print(json.dumps({"status": "error", "message": "No path found"}))
    except Exception as e:
        print(json.dumps({"status": "error", "message": str(e)}))